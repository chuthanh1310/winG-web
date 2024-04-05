function Footer(){
    return(
      <div>
      <div className="w3-display-container">
        <img src="../pic/contact.jpg" className="contact-img" />
        <div className="w3-display-left w3-container">
          <h2 className="w3-text-white w3-padding-large"><b>Contact us now!</b></h2>
          <p className="w3-text-white w3-padding-large">Lorem ipsum dolor sit amet,consectecur adipisicing elit</p>
        </div>
        <div className="w3-display-right w3-container">
          <button className="w3-button w3-orange w3-round-xxlarge w3-padding-large" style={{ margin: '0 100px' }} onClick={() => navigateToPage('contact.html')}>Contact now</button>
        </div>
      </div>
      <div className="footer">
        <div className="w3-row">
          <div className="w3-col w3-black w3-container" style={{ width: '30%' }}>
            <h4><b>About</b></h4>
            <p className="w3-text-gray">Lorem ipsum viverra feugiat.Pellen tesque libero ut justo,ultrices in ligula.Semper at tempufddfel.Lorem ipsum dolor sit,l.Lorem ipsum dolor sit,amet alit</p>
            <button className="w3-button w3-circle " style={{ backgroundColor: 'rgb(235, 77, 20)', marginTop: '15px' ,marginRight:'10px'}}><i className="fa-brands fa-facebook"></i></button>
            <button className="w3-button w3-circle " style={{ backgroundColor: 'rgb(235, 77, 20)' , marginTop: '15px',marginRight:'10px' }}><i className="fa-brands fa-twitter"></i></button>
            <button className="w3-button w3-circle " style={{ backgroundColor: 'rgb(235, 77, 20)', marginTop: '15px' ,marginRight:'10px' }}><i className="fa-brands fa-instagram"></i></button>
            <button className="w3-button w3-circle " style={{ backgroundColor: 'rgb(235, 77, 20)' , marginTop: '15px' ,marginRight:'10px'}}><i className="fa-brands fa-google-plus"></i></button>
          </div>
          <div className="w3-col w3-black w3-container" style={{ width: '20%' }}>
            <h4 className="w3-center"><b>Links</b></h4>
            <div className="w3-bar-block">
              <div className="w3-bar-item"><button className="button-item" onClick={() => navigateToPage('home.html')} >Home</button></div>
              <div className="w3-bar-item"><button className="button-item" onClick={() => navigateToPage('about.html')}>About us</button></div>
              <div className="w3-bar-item"><button className="button-item" onClick={() => navigateToPage('artist.html')}>Artist</button></div>
              <div className="w3-bar-item"><button className="button-item" onClick={() => navigateToPage('contact.html')}>Contact</button></div>
            </div>
          </div>
          <div className="w3-col w3-black w3-container" style={{ width: '20%' }}>
            <h4 className="w3-center"><b>Products</b></h4>
            <div className="w3-bar-block">
              <div className="w3-bar-item"><button className="button-item">2D art</button></div>
              <div className="w3-bar-item"><button className="button-item">3D art</button></div>
              <div className="w3-bar-item"><button className="button-item">Manga</button></div>
              <div className="w3-bar-item"><button className="button-item">Manhua</button></div>
            </div>
          </div>
          <div className="w3-col w3-black w3-container" style={{ width: '30%' }}>
            <h4><b>Twitter Feed</b></h4>
            <div className="w3-row">
              <div className="w3-col" style={{ width: '10%' }}><i className="fa-brands fa-twitter" style={{ marginTop: '15px' }}></i></div>
              <div className="w3-col" style={{ width: '90%' }}>
                <p><span>@Honynilf </span><span style={{ color: 'gray' }}>Hi </span><span>@Honynilf </span><span style={{ color: 'gray' }}>, can you please submit a ticket at</span><span>https://v.co/ị123A34J45A</span></p>
                <p style={{ color: 'gray' }}>1 year ago</p>
              </div>
            </div>
            <h4><b>Twitter Feed</b></h4>
            <div className="w3-row">
              <div className="w3-col" style={{ width: '10%' }}><i className="fa-brands fa-twitter" style={{ paddingTop: '15px' }}></i></div>
              <div className="w3-col" style={{ width: '90%' }}>
                <p><span>@Honynilf </span><span style={{ color: 'gray' }}>Hi </span><span>@Honynilf </span><span style={{ color: 'gray' }}>, can you please submit a ticket at</span><span>https://v.co/ị123A34J45A</span><span style={{ color: 'gray' }}> and one of our support agent ....</span></p>
                <p style={{ color: 'gray' }}>2 year ago</p>
              </div>
            </div>
          </div>
        </div>
        <div className="w3-right-align"><a href="#" className="back-to-top-button" id="backToTopButton">&#9650;</a></div>
      </div>
    </div>
    );
  }
  
  ReactDOM.render(<Footer/>,document.getElementById('footer'))
