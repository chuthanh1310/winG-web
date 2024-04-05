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
  function changeContent() {  
    var content = document.getElementById('content');
    content.innerHTML = `
    <div class="w3-row w3-container" style="padding:0 50px;">
        <div class="w3-row">
            <div class="w3-col l9 s6">
                <div class="w3-col l3 s6">
                    <img src="../pic/thiếu niên ca hành.jpg" alt="Alps" style="width:100%">
                </div>
                <div class="w3-col l9 s6" style="padding:50px 20px;border-bottom:1px solid gray">
                    <h4><b>Thiếu niên ca hành</b></h4>
                    <div class="w3-row">
                        <div class="w3-col s3 ">
                            <p><b>Tên khác </b></p>
                            <p><b>Só tập</b></p>
                            <p><b>Nước SX </b></p>
                            <p><b>Thể loại </b></p>
                            <p><b>Cập nhật đến </b></p>
                        </div>
                        <div class="w3-col s9 ">
                            <p>Shiaonan Ge Xing</p>
                            <p>Đang cập nhật</p>
                            <p>Trung Quốc</p>
                            <p><span style="color:blue;">Kỳ ảo,Phiêu lưu,TV Show,Lịch sử,Hành Động,Ngôn Tình,Võ Thuật,Trinh
                                    Thám,Tình Cảm,Thanh Xuân,Cổ Trang</span> </p>
                            <p><span style="color:blue;">Tập 10-Phần 3,Tập11-Phần 3 Ngang RAW</span></p>
                        </div>
                    </div>
                </div>

                <div class="card">
                    <input id="ch" type="checkbox">
                    <h2> Tóm Tắt</h2>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris non risus sed ex blandit condimentum.
                        Vestibulum
                        non mauris non est vestibulum viverra. Nam vel elit vel est vehicula finibus. Quisque nec mi sit amet ligula
                        luctus aliquet ...</p>
                    <div class="content">
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris non risus sed ex blandit condimentum.
                            Vestibulum non mauris non est vestibulum viverra. Nam vel elit vel est vehicula finibus. Quisque nec mi sit
                            amet ligula
                            luctus aliquet.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris non risus sed ex blandit
                            condimentum. Vestibulum non mauris non est vestibulum viverra. Nam vel elit vel est vehicula finibus.
                            Quisque nec mi sit amet ligula luctus aliquet.Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                            Mauris non
                            risus sed ex blandit condimentum. Vestibulum non mauris non est vestibulum viverra. Nam vel elit vel est
                            vehicula
                            finibus. Quisque nec mi sit amet ligula luctus aliquet.Lorem ipsum dolor sit amet, consectetur adipiscing
                            elit.Mauris non risus sed ex blandit condimentum. Vestibulum non mauris non est vestibulum viverra. Nam
                            vel elit
                            vel est vehicula finibus. Quisque nec mi sit amet ligula luctus aliquet.Lorem ipsum dolor sit amet,
                            consectetur
                            adipiscing elit. Mauris non risus sed ex blandit condimentum. Vestibulum non mauris non est vestibulum
                            viverra.Nam vel
                            elit vel est vehicula finibus. Quisque nec mi sit amet ligula luctus aliquet.</p>
                        <label for="ch" class="hide">Thu gọn</label>
                    </div>
                    <label for="ch">Read More</label>
                </div>
                <h2>Danh sách tập</h2>
                <div class="scroll-container">
                    <table>
                      <thead>
                        <tr>
                          <th>Tên</th>
                          <th>Cập nhật</th>
                          <th>Lượt truy cập</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr class="button-row" onclick="handleRowClick('aaa.html')">
                          <td>tập 11-phần 3 ngang raw</td>
                          <td>20/03/2024</td>
                          <td>100</td>
                        </tr>
                        <tr class="button-row" onclick="handleRowClick('aaa.html')">
                          <td>tập 10-phần 3</td>
                          <td>22/03/2024</td>
                          <td>150</td>
                        </tr>
                        <tr class="button-row" onclick="handleRowClick('aaa.html')">
                            <td>tập 9-phần 3</td>
                            <td>22/03/2024</td>
                            <td>150</td>
                        </tr>
                        <tr class="button-row" onclick="handleRowClick('aaa.html')">
                            <td>tập 8-phần 3</td>
                            <td>22/03/2024</td>
                            <td>150</td>
                        </tr>
                        <tr class="button-row" onclick="handleRowClick('aaa.html')">
                            <td>tập 7-phần 3</td>
                            <td>22/03/2024</td>
                            <td>150</td>
                        </tr>
                        <tr class="button-row" onclick="handleRowClick('aaa.html')">
                            <td>tập 6-phần 3</td>
                            <td>22/03/2024</td>
                            <td>60</td>
                        </tr>
                        <tr class="button-row" onclick="handleRowClick('aaa.html')">
                            <td>tập 5-phần 3</td>
                            <td>22/03/2024</td>
                            <td>10</td>
                        </tr>
                        <tr class="button-row" onclick="handleRowClick('aaa.html')">
                            <td>tập 4-phần 3</td>
                            <td>22/03/2024</td>
                            <td>150</td>
                        </tr>
                        <tr class="button-row" onclick="handleRowClick('aaa.html')">
                            <td>tập 3-phần 3</td>
                            <td>22/03/2024</td>
                            <td>0</td>
                        </tr>
                        <tr class="button-row" onclick="handleRowClick('aaa.html')">
                            <td>tập 2-phần 3</td>
                            <td>22/03/2024</td>
                            <td>15</td>
                        </tr>
                        <tr class="button-row" onclick="handleRowClick('aaa.html')">
                            <td>tập 1-phần 3</td>
                            <td>22/03/2024</td>
                            <td>150</td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
                  
            </div>
            <div class="w3-col l3 s6">
                <h2>MỚI CẬP NHẬT</h2>
                <div class="scroller">
                    <div class="w3-row">
                        <div class="w3-col l2 s3">
                            <img src="../pic/đại sư phụ hạ sơn.jfif" style="width:100%">
                        </div>
                        <div class="w3-col l10 s9">
                            <p><i class="fa-solid fa-images"></i><b>    Đại sư phụ hạ sơn</b></p>
                            <P class="w3-text-grey">28/12/2023 15:01</P>
                        </div>
                    </div>
                    <div class="w3-row">
                        <div class="w3-col l2 s3">
                            <img src="../pic/đại sư phụ hạ sơn.jfif" style="width:100%">
                        </div>
                        <div class="w3-col l10 s9">
                            <p><i class="fa-solid fa-images"></i><b>    Đại sư phụ hạ sơn</b></p>
                            <P class="w3-text-grey">28/12/2023 15:01</P>
                        </div>
                    </div>
                    <div class="w3-row">
                        <div class="w3-col l2 s3">
                            <img src="../pic/đại sư phụ hạ sơn.jfif" style="width:100%">
                        </div>
                        <div class="w3-col l10 s9">
                            <p><i class="fa-solid fa-images"></i><b>    Đại sư phụ hạ sơn</b></p>
                            <P class="w3-text-grey">28/12/2023 15:01</P>
                        </div>
                    </div>
                    <div class="w3-row">
                        <div class="w3-col l2 s3">
                            <img src="../pic/đại sư phụ hạ sơn.jfif" style="width:100%">
                        </div>
                        <div class="w3-col l10 s9">
                            <p><i class="fa-solid fa-images"></i><b>    Đại sư phụ hạ sơn</b></p>
                            <P class="w3-text-grey">28/12/2023 15:01</P>
                        </div>
                    </div>
                    <div class="w3-row">
                        <div class="w3-col l2 s3">
                            <img src="../pic/đại sư phụ hạ sơn.jfif" style="width:100%">
                        </div>
                        <div class="w3-col l10 s9">
                            <p><i class="fa-solid fa-images"></i><b>    Đại sư phụ hạ sơn</b></p>
                            <P class="w3-text-grey">28/12/2023 15:01</P>
                        </div>
                    </div>
                    <div class="w3-row">
                        <div class="w3-col l2 s3">
                            <img src="../pic/đại sư phụ hạ sơn.jfif" style="width:100%">
                        </div>
                        <div class="w3-col l10 s9">
                            <p><i class="fa-solid fa-images"></i><b>    Đại sư phụ hạ sơn</b></p>
                            <P class="w3-text-grey">28/12/2023 15:01</P>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    `;
  }
  document.addEventListener('DOMContentLoaded', function() {
    const showMoreButton = document.getElementById('show-more-btn');
    const additionalContent = document.querySelector('.additional-content');

    showMoreButton.addEventListener('click', function() {
        if (additionalContent.style.display === 'none') {
            additionalContent.style.display = 'block';
            showMoreButton.textContent = 'Thu gọn';
        } else {
            additionalContent.style.display = 'none';
            showMoreButton.textContent = 'Xem thêm';
        }
    });
});
document.addEventListener('DOMContentLoaded', function () {
  var ch = document.getElementById('ch');
  var content = document.querySelector('.content');
  var readMoreBtn = document.querySelector('label[for="ch"]');

  ch.addEventListener('change', function () {
      if (this.checked) {
          content.style.display = 'block';
          readMoreBtn.classList.remove('hide');
      } else {
          content.style.display = 'none';
          readMoreBtn.classList.add('hide');
      }
  });
});
function handleRowClick(url) {
  window.location.href = url;
}

