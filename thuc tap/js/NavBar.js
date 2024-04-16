function NavBar(props) {
  const {
    homeLinkColor = 'white',
    artistLinkColor = 'white',
    aboutLinkColor = 'white',
    productLinkColor = 'white',
    contactLinkColor = 'white'
    
  } = props;

  return (
    <div>
      <div className="w3-bar w3-white">
        <div className="w3-bar-item" style={{ color: 'gray' }}>Have any question?</div>
        <div className="w3-bar-item"><a href="#"><i className="fa fa-phone"></i>+1(21) 234 4567</a></div>
        <div className="w3-bar-item"><i className="fa fa-envelope"></i>mail@example.com</div>
        <div className="w3-bar-item w3-right"><img src="../pic/vietnam.png" style={{ width: '30px' }} alt="Flag" /></div>
        <div className="w3-bar-item w3-right"><i className="fa-brands fa-linkedin-in"></i></div>
        <div className="w3-bar-item w3-right"><i className="fa-brands fa-instagram"></i></div>
        <div className="w3-bar-item w3-right"><i className="fa-brands fa-twitter"></i></div>
        <div className="w3-bar-item w3-right"><i className="fa-brands fa-facebook"></i></div>
      </div>
      <div className="w3-bar w3-black w3-padding">
        <button className="w3-bar-item w3-button w3-circle w3-gray w3-right"><i className="fa fa-angle-double-right"></i></button>
        <div className="w3-bar-item w3-right"><i className="fa fa-moon-o" style={{ fontSize: '24px' }}></i></div>
        <a href="#" className="w3-bar-item w3-button w3-right w3-orange" style={{ borderRadius: '0  20px 20px 0' }}><i className="fa fa-search"></i></a>
        <input type="text" className="w3-bar-item w3-input w3-white w3-mobile w3-right" style={{ borderRadius: '20px 0 0 20px' }} placeholder="Enter Keyword.." />
        <a href="../html/contact.html" className="w3-bar-item w3-button w3-right w3-hover-none w3-hover-text-grey" style={{ color: contactLinkColor }}>Contact</a>
        <div className="w3-dropdown-hover w3-mobile w3-right">
          <button className="w3-button " style={{ color: productLinkColor }}>Product <i className="fa fa-caret-down"></i></button>
          <div className="w3-dropdown-content w3-bar-block w3-white">
            <a href="../html/2d.html" className="w3-bar-item w3-button w3-hover-none w3-text-black w3-hover-text-orange w3-mobile">2D art</a>
        
            <a href="../html/truyen.html" className="w3-bar-item w3-button w3-hover-none w3-text-black w3-hover-text-orange w3-mobile">Truyện tranh</a>
            <a href="../html/music.html" className="w3-bar-item w3-button w3-hover-none w3-text-black w3-hover-text-orange w3-mobile" >Music Video</a>
            <a href="../html/Albums.html" className="w3-bar-item w3-button w3-hover-none w3-text-black w3-hover-text-orange w3-mobile" >Album/Singles</a>
          </div>
        </div>
        <a href="../html/artist.html" className="w3-bar-item w3-button w3-right w3-hover-none w3-hover-text-grey" style={{ color: artistLinkColor }}>Artist</a>
        <a href="../html/about.html" className="w3-bar-item w3-button w3-right w3-hover-none w3-hover-text-grey" style={{ color: aboutLinkColor }}>About us</a>
        <a href="../html/home.html" className="w3-bar-item w3-button w3-right w3-hover-none w3-hover-text-grey" style={{ color: homeLinkColor }}>Home</a>
      </div>
    </div>
  );
}




