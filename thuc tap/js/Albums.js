function changeContent() {   
    var content = document.getElementById('content');
    content.innerHTML = `
    <div class="w3-row">
    <div class="w3-col s6" style="padding: 20px 5%;">
    <img src="../pic/từ chối.jpg" style="width:100%">
    </div>
    <div class="w3-col s6" style="padding: 20px 5%;">
    <h2 class="w3-padding-large"><b>từ chối nhẹ nhàng thôi</b></h3>
              <p><b>Single</b></p>
              <p><b>Genre:</b>Pop/Rap</p>
              <p><b>Record Label:</b>1989s Entertainment</p>
              <p><b>Release Date:</b>18/06/2020</p>
              <p><b>Composers:</b>Tiên Cookie,Phạm Thanh Hà,Phúc Du</p>
              <p></p>
              
              <h3><b>Listen on</b></h3>
              <div class="w3-bar ">
                
                <div class="w3-bar-item"><i class="fa-brands fa-spotify"></i><b>  SPOTIFY     </b></div>
                <div class="w3-bar-item"><i class="fa-brands fa-apple"></i><b>  APPLE MUSIC    </b></div>
                <div class="w3-bar-item"><i class="fa fa-music"></i><b>  NHACCUATUI     </b></div>
              </div>       
    </div>
    </div>
    <div class=" w3-center">
        <h2><b>track list</b></h2>
    </div>
    <div class="track">
    <p class="text-track">từ chối nhẹ nhàng thôi</p>
    <i class="fa fa-youtube-play youtube-icon"style="font-size:24px"></i>
    </div>   
    `;
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
function navigateToPage(pageUrl) {
    // Thiết lập đường dẫn của trang HTML mục tiêu từ tham số truyền vào
    window.location.href = pageUrl;
}