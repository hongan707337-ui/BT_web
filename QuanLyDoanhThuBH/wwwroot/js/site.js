document.addEventListener('DOMContentLoaded', () => {
    const revenueCards = document.querySelectorAll('.doanh-thu-card');

    revenueCards.forEach(card => {
        card.addEventListener('mouseover', () => {
            card.style.transform = 'translateY(-5px)';
            card.style.boxShadow = '0 8px 16px rgba(0, 0, 0, 0.2)';
        });

        card.addEventListener('mouseout', () => {
            card.style.transform = 'translateY(0)';
            card.style.boxShadow = '0 4px 8px rgba(0, 0, 0, 0.1)';
        });
    });
});
document.addEventListener('DOMContentLoaded', () => {
    const fadeInElements = document.querySelectorAll('.fade-in-section');

    const observer = new IntersectionObserver((entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('is-visible');
                observer.unobserve(entry.target);
            }
        });
    }, {
        threshold: 0.2 // Kích hoạt khi 20% phần tử xuất hiện
    });

    fadeInElements.forEach(element => {
        observer.observe(element);
    });
});
document.addEventListener('DOMContentLoaded', () => {
    // Lấy dữ liệu từ ViewBag của ASP.NET
    const labels = JSON.parse(document.getElementById('chart-labels').innerText);
    const data = JSON.parse(document.getElementById('chart-data').innerText);

    const ctx = document.getElementById('doanhThuChart').getContext('2d');
    const myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Tổng Doanh Thu (VNĐ)',
                data: data,
                backgroundColor: 'rgba(54, 162, 235, 0.2)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 1,
                fill: true,
                tension: 0.4
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true,
                    title: {
                        display: true,
                        text: 'Doanh Thu'
                    }
                },
                x: {
                    title: {
                        display: true,
                        text: 'Tháng'
                    }
                }
            }
        }
    });
});
document.addEventListener('DOMContentLoaded', function () {
    const fadeInSections = document.querySelectorAll('.fade-in-section');

    const observer = new IntersectionObserver((entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = 1;
                entry.target.style.transform = 'translateY(0)';
                observer.unobserve(entry.target);
            }
        });
    }, { threshold: 0.1 });

    fadeInSections.forEach(section => {
        section.style.opacity = 0;
        section.style.transform = 'translateY(20px)';
        section.style.transition = 'opacity 0.6s ease-in, transform 0.6s ease-in';
        observer.observe(section);
    });
});
document.addEventListener('DOMContentLoaded', function () {
    const primaryButtons = document.querySelectorAll('.btn-primary');

    primaryButtons.forEach(button => {
        button.addEventListener('mouseover', function () {
            this.style.backgroundColor = '#155598'; // Màu đậm hơn khi hover
            this.style.transition = 'background-color 0.3s ease';
        });

        button.addEventListener('mouseout', function () {
            this.style.backgroundColor = '#1b6ec2'; // Trở lại màu gốc
        });
    });
});
document.addEventListener('DOMContentLoaded', function () {
    const navbar = document.querySelector('.navbar'); // Đặt class cho thanh nav của bạn

    window.addEventListener('scroll', () => {
        if (window.scrollY > 50) {
            navbar.style.backgroundColor = 'rgba(255, 255, 255, 0.9)';
            navbar.style.boxShadow = '0 2px 4px rgba(0,0,0,.1)';
        } else {
            navbar.style.backgroundColor = 'transparent';
            navbar.style.boxShadow = 'none';
        }
    });
});
var slideIndex = 1;
showSlides(slideIndex);

// Điều khiển slide bằng nút mũi tên
function plusSlides(n) {
    showSlides(slideIndex += n);
}

// Điều khiển slide bằng dấu chấm
function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");

    if (n > slides.length) {
        slideIndex = 1
    }
    if (n < 1) {
        slideIndex = slides.length
    }

    // Ẩn tất cả các slide
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }

    // Bỏ trạng thái active của tất cả các dấu chấm
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }

    // Hiển thị slide hiện tại
    slides[slideIndex - 1].style.display = "block";

    // Thêm trạng thái active cho dấu chấm tương ứng
    dots[slideIndex - 1].className += " active";
}

// Tự động chuyển slide sau mỗi 5 giây
var autoSlideIndex = 0;
var autoSlideInterval;

function autoShowSlides() {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");

    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }

    autoSlideIndex++;
    if (autoSlideIndex > slides.length) {
        autoSlideIndex = 1
    }

    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }

    slides[autoSlideIndex - 1].style.display = "block";
    dots[autoSlideIndex - 1].className += " active";

    // Nếu là slide cuối cùng, dừng tự động chuyển
    if (autoSlideIndex === slides.length) {
        clearInterval(autoSlideInterval);
    }
}

// Gọi hàm tự động chuyển slide lần đầu và thiết lập interval
document.addEventListener('DOMContentLoaded', function () {
    autoShowSlides();
    autoSlideInterval = setInterval(autoShowSlides, 5000); // 5000ms = 5 giây
});
// Thêm đoạn code này vào <script> của bạn
document.addEventListener('DOMContentLoaded', function () {
    var images = document.querySelectorAll('.mySlides img');
    images.forEach(function (img) {
        var newImg = new Image();
        newImg.src = img.src;
    });
});