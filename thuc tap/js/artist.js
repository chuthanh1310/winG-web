function navigateToPage(pageUrl) {
    // Thiết lập đường dẫn của trang HTML mục tiêu từ tham số truyền vào
    window.location.href = pageUrl;
}
document.getElementById('backToTopButton').addEventListener('click', function(event) {
    event.preventDefault(); // Ngăn chặn hành động mặc định của thẻ a
    window.scrollTo({
      top: 0,
      behavior: 'smooth'
    });
  });
  
  window.addEventListener('scroll', function() {
    var button = document.getElementById('backToTopButton');
    if (window.scrollY > 300) {
      button.style.display = 'block';
    } else {
      button.style.display = 'none';
    }
});
