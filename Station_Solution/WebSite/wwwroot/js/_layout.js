(() => {
    "use strict";

    // =========================
    // Helpers
    // =========================
    const qs = (sel, root = document) => root.querySelector(sel);

    function setText(id, value) {
        const el = document.getElementById(id);
        if (el) el.textContent = (value ?? "—");
    }

    function formatTRY(value) {
        // value: number | string
        const n = typeof value === "string" ? Number(value.replace(",", ".")) : Number(value);
        if (!Number.isFinite(n)) return "—";
        return new Intl.NumberFormat("tr-TR", { minimumFractionDigits: 2, maximumFractionDigits: 2 }).format(n);
    }

    function formatDateTimeTR(date) {
        try {
            return new Intl.DateTimeFormat("tr-TR", {
                dateStyle: "medium",
                timeStyle: "short"
            }).format(date);
        } catch {
            return date.toLocaleString();
        }
    }

    // =========================
    // Swiper Init
    // =========================
    function initHeroSwiper() {
        if (typeof Swiper === "undefined") return;
        const el = qs(".heroSwiper");
        if (!el) return;

        new Swiper(".heroSwiper", {
            loop: true,
            autoplay: { delay: 4500, disableOnInteraction: false },
            pagination: { el: ".swiper-pagination", clickable: true },
            navigation: { nextEl: ".swiper-button-next", prevEl: ".swiper-button-prev" }
        });
    }

    // =========================
    // Navbar active link (simple scroll spy)
    // =========================
    function initScrollSpy() {
        const links = Array.from(document.querySelectorAll(".navbar-nav .nav-link"))
            .filter(a => a.getAttribute("href")?.startsWith("#"));

        if (!links.length) return;

        const map = links
            .map(a => {
                const id = a.getAttribute("href").slice(1);
                const section = document.getElementById(id);
                return section ? { a, section } : null;
            })
            .filter(Boolean);

        if (!map.length) return;

        const obs = new IntersectionObserver((entries) => {
            // En görünür olanı aktif yap
            const visible = entries
                .filter(e => e.isIntersecting)
                .sort((a, b) => b.intersectionRatio - a.intersectionRatio)[0];

            if (!visible) return;

            map.forEach(x => x.a.classList.remove("active"));
            const item = map.find(x => x.section === visible.target);
            if (item) item.a.classList.add("active");
        }, { rootMargin: "-30% 0px -60% 0px", threshold: [0.1, 0.2, 0.3, 0.4, 0.5] });

        map.forEach(x => obs.observe(x.section));
    }

    // =========================
    // Smooth scroll + close mobile menu
    // =========================
    function initSmoothAnchors() {
        document.addEventListener("click", (e) => {
            const a = e.target.closest("a[href^='#']");
            if (!a) return;

            const href = a.getAttribute("href");
            if (!href || href === "#") return;

            const target = document.querySelector(href);
            if (!target) return;

            e.preventDefault();
            target.scrollIntoView({ behavior: "smooth", block: "start" });

            // close mobile navbar if open
            const nav = document.getElementById("mainNav");
            if (nav?.classList.contains("show")) {
                const bsCollapse = bootstrap.Collapse.getInstance(nav) || new bootstrap.Collapse(nav);
                bsCollapse.hide();
            }
        });
    }

    // =========================
    // Scroll to top button
    // =========================
    function initScrollTop() {
        const btn = document.getElementById("scrollTopBtn");
        if (!btn) return;

        const toggle = () => {
            const show = window.scrollY > 600;
            btn.classList.toggle("show", show);
        };
        toggle();

        window.addEventListener("scroll", toggle, { passive: true });
        btn.addEventListener("click", () => window.scrollTo({ top: 0, behavior: "smooth" }));
    }

    // =========================
    // Footer Year
    // =========================
    function initFooterYear() {
        const y = document.getElementById("footerYear");
        if (y) y.textContent = new Date().getFullYear();
    }

    // =========================
    // Fuel Price UI Update (Firestore listener bunu çağıracak)
    // IDs (Index.cshtml ile uyumlu):
    // benzinPrice, dizelPrice, eurodieselPrice, lpgPrice, fuelPricesUpdatedAt
    // =========================
    window.updateFuelPrices = function (prices, updatedAt) {
        // prices: { benzin, dizel, eurodiesel, lpg }
        setText("benzinPrice", prices?.benzin != null ? `₺ ${formatTRY(prices.benzin)}` : "—");
        setText("dizelPrice", prices?.dizel != null ? `₺ ${formatTRY(prices.dizel)}` : "—");
        setText("eurodieselPrice", prices?.eurodiesel != null ? `₺ ${formatTRY(prices.eurodiesel)}` : "—");
        setText("lpgPrice", prices?.lpg != null ? `₺ ${formatTRY(prices.lpg)}` : "—");

        if (updatedAt) {
            const d = updatedAt instanceof Date ? updatedAt : new Date(updatedAt);
            setText("fuelPricesUpdatedAt", formatDateTimeTR(d));
        } else {
            setText("fuelPricesUpdatedAt", "—");
        }
    };

    // =========================
    // Firestore Listener (compat)
    // =========================
    function initFirestoreFuelListener() {
        // Firebase SDK yoksa (veya kullanmak istemiyorsan) sessizce çık
        if (typeof firebase === "undefined") return;
        if (!firebase.apps) return;

        // 1) Burayı kendi Firebase projenle doldur
        const firebaseConfig = {
            apiKey: "AIzaSyBjtIVXc6fTKsXHydHtEAc6P6wV9s0CaIY",
            authDomain: "gasstation-3d1c9.firebaseapp.com",
            projectId: "gasstation-3d1c9",
            storageBucket: "gasstation-3d1c9.firebasestorage.app",
            messagingSenderId: "198731592843",
            appId: "1:198731592843:web:4790685d3a8ed13b6b508e",
            measurementId: "G-CRDBMQ8SZ1"
        };
        const collectionName = "fuel_prices";
        const docId = "H7fuqMKrNktFPtTmEDhO";

        try {
            if (!firebase.apps.length) firebase.initializeApp(firebaseConfig);

            const db = firebase.firestore();

            db.collection(collectionName).doc(docId).onSnapshot(
                (snap) => {
                    console.log("fuel snapshot:", snap.exists, snap.id);

                    if (!snap.exists) {
                        window.updateFuelPrices(null, null);
                        return;
                    }

                    const data = snap.data() || {};
                    console.log("fuel data:", data);

                    // ✅ Firestore field adlarınla birebir eşle
                    const prices = {
                        benzin: data.Benzin,
                        dizel: data.Diesel,
                        eurodiesel: data.EuroDiesel,
                        lpg: data.LPG
                    };

                    // ✅ Timestamp alanın: LastUpdate
                    let updatedAt = null;
                    if (data.LastUpdate?.toDate) updatedAt = data.LastUpdate.toDate();
                    else if (data.LastUpdate) updatedAt = data.LastUpdate;

                    window.updateFuelPrices(prices, updatedAt);
                },
                (err) => console.error("Firestore fuel listener error:", err)
            );
        } catch (e) {
            console.error("Firebase init error:", e);
        }
    }

    // =========================
    // Boot
    // =========================
    document.addEventListener("DOMContentLoaded", () => {
        initHeroSwiper();
        initScrollSpy();
        initSmoothAnchors();
        initScrollTop();
        initFooterYear();

        // Index sayfasında fuel-prices paneli varsa dinleyiciyi başlat
        if (document.getElementById("fuel-prices")) {
            initFirestoreFuelListener();
        }
    });

})();
