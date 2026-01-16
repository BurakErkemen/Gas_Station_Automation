// Sayfa yüklendiğinde çalışacak fonksiyonlar
document.addEventListener('DOMContentLoaded', function () {
    // Mobil menü toggle
    const mobileMenuBtn = document.getElementById('mobileMenuBtn');
    const mobileMenu = document.getElementById('mobileMenu');

    if (mobileMenuBtn && mobileMenu) {
        mobileMenuBtn.addEventListener('click', () => {
            mobileMenu.classList.toggle('active');
        });
    }

    // Smooth scroll için tüm bağlantıları dinle
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();

            const targetId = this.getAttribute('href');
            if (targetId === '#') return;

            const targetElement = document.querySelector(targetId);
            if (targetElement) {
                // Mobil menüyü kapat
                if (mobileMenu) {
                    mobileMenu.classList.remove('active');
                }

                window.scrollTo({
                    top: targetElement.offsetTop - 80,
                    behavior: 'smooth'
                });

                // URL hash'ini güncelle (isteğe bağlı)
                history.pushState(null, null, targetId);
            }
        });
    });

    // Navbar aktif link güncelleme
    window.addEventListener('scroll', () => {
        const sections = document.querySelectorAll('section[id]');
        const navLinks = document.querySelectorAll('.main-nav a, .mobile-nav-link');

        let current = '';

        sections.forEach(section => {
            const sectionTop = section.offsetTop;
            const sectionHeight = section.clientHeight;

            if (window.scrollY >= (sectionTop - 100)) {
                current = section.getAttribute('id');
            }
        });

        navLinks.forEach(link => {
            link.classList.remove('nav-active');
            if (link.getAttribute('href') === `#${current}`) {
                link.classList.add('nav-active');
            }
        });
    });

    // Fiyat güncelleme fonksiyonu (örnek)
    function updateFuelPrices() {
        const prices = {
            'benzin': 38.95,
            'dizel': 36.75,
            'lpg': 22.45,
            'eurodiesel': 37.25
        };

        // Burada API'den güncel fiyatlar çekilebilir
        console.log('Yakıt fiyatları güncellendi:', prices);

        // Fiyatları DOM'da güncelle
        const priceElements = document.querySelectorAll('.fuel-price');
        if (priceElements.length === 4) {
            priceElements[0].textContent = prices.benzin.toFixed(2);
            priceElements[1].textContent = prices.dizel.toFixed(2);
            priceElements[2].textContent = prices.lpg.toFixed(2);
            priceElements[3].textContent = prices.eurodiesel.toFixed(2);
        }
    }

    // Sayfa yüklendiğinde fiyatları güncelle
    updateFuelPrices();

    // Servis kartlarına hover efekti
    const serviceCards = document.querySelectorAll('.service-card');
    serviceCards.forEach(card => {
        card.addEventListener('mouseenter', function () {
            this.style.transform = 'translateY(-10px)';
        });

        card.addEventListener('mouseleave', function () {
            this.style.transform = 'translateY(0)';
        });
    });

    // İletişim kartlarına hover efekti
    const contactCards = document.querySelectorAll('.contact-card');
    contactCards.forEach(card => {
        card.addEventListener('mouseenter', function () {
            this.style.transform = 'translateY(-5px)';
        });

        card.addEventListener('mouseleave', function () {
            this.style.transform = 'translateY(0)';
        });
    });

    // Galeri öğelerine hover efekti
    const galleryItems = document.querySelectorAll('.gallery-item');
    galleryItems.forEach(item => {
        item.addEventListener('mouseenter', function () {
            this.style.transform = 'translateY(-5px)';
        });

        item.addEventListener('mouseleave', function () {
            this.style.transform = 'translateY(0)';
        });
    });

    // Sosyal medya ikonlarına hover efekti
    const socialIcons = document.querySelectorAll('.social-icon');
    socialIcons.forEach(icon => {
        icon.addEventListener('mouseenter', function () {
            this.style.transform = 'translateY(-3px)';
        });

        icon.addEventListener('mouseleave', function () {
            this.style.transform = 'translateY(0)';
        });
    });

    // Güncel tarihi footer'a ekle
    const currentYear = new Date().getFullYear();
    const yearElement = document.querySelector('.footer-bottom p');
    if (yearElement) {
        yearElement.innerHTML = yearElement.innerHTML.replace('2023', currentYear);
    }

    // Fiyat güncelleme tarihini güncelle
    const today = new Date();
    const formattedDate = `${today.getDate().toString().padStart(2, '0')}.${(today.getMonth() + 1).toString().padStart(2, '0')}.${today.getFullYear()}`;
    const dateElement = document.querySelector('.price-update p');
    if (dateElement) {
        dateElement.textContent = `Fiyatlar günlük olarak güncellenmektedir. Son güncelleme: ${formattedDate}`;
    }

    // Console'a hoş geldin mesajı
    console.log('%cKahramanlar Belen Akaryakıt 🚗⛽', 'color: #c00a1e; font-size: 16px; font-weight: bold;');
    console.log('%cHatay/Belen\'in güvenilir akaryakıt noktasına hoş geldiniz!', 'color: #0033a0;');
});