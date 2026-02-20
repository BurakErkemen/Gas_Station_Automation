(() => {
    "use strict";

    function setText(id, v) {
        const el = document.getElementById(id);
        if (el) el.textContent = v ?? "—";
    }

    document.addEventListener("DOMContentLoaded", () => {
        // Status göstergeleri (taslak)
        setText("fsStatus", typeof firebase !== "undefined" ? "Hazır" : "Yok");
        setText("streamStatus", "Beklemede");

        // Yenile butonu (taslak)
        const refreshBtn = document.getElementById("refreshBtn");
        if (refreshBtn) {
            refreshBtn.addEventListener("click", () => {
                refreshBtn.disabled = true;
                refreshBtn.innerHTML = `<span class="spinner-border spinner-border-sm me-2"></span>Yenileniyor`;
                setTimeout(() => {
                    refreshBtn.disabled = false;
                    refreshBtn.innerHTML = `<i class="fa-solid fa-rotate me-2"></i>Yenile`;
                }, 650);
            });
        }

        // Modal form submit (taslak)
        const form = document.getElementById("priceForm");
        const btn = document.getElementById("savePricesBtn");
        const sp = document.getElementById("saveSpinner");

        if (form && btn) {
            form.addEventListener("submit", (e) => {
                e.preventDefault();

                btn.disabled = true;
                if (sp) sp.classList.remove("d-none");

                // Taslak: burada Firestore update veya server endpoint çağıracağız
                setTimeout(() => {
                    btn.disabled = false;
                    if (sp) sp.classList.add("d-none");
                    alert("Taslak: Kaydetme işlemi daha bağlanmadı. Sonraki adımda Firestore'a yazacağız.");
                }, 700);
            });
        }
    });
})();
