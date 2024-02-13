import {React,useState} from "react";
import LoginPopup from "../Common/LoginPoup";
import '../Styles/LandingPage.css'


const LandingPage = () => {
  const [isLoginPopupOpen, setLoginPopupOpen] = useState(false);

  const openLoginPopup = () => {
    setLoginPopupOpen(true);
  };

  const closeLoginPopup = () => {
    setLoginPopupOpen(false);
  };
    return (
        <div className="landing-page-container">
        <div className="landing-page">
          <section className="right-section">
            <div className="message">
              <h2>Let's Start<br />Bidding</h2>
            </div>
            <div className="info">
              <p>Your premier online auction platform, BidNest, provides a secure and exciting marketplace for buying and selling a wide variety of items. Join our community and start bidding today!</p>
            </div>
            <button class="get-started"onClick={openLoginPopup}>Get Started</button>
          </section>
          <section className="left-section">
            <img src={require('../../Assets/Auction.png')} alt="Auction" />
          </section>
        </div>
        {isLoginPopupOpen && <LoginPopup onClose={closeLoginPopup}  />}
      </div>
    );
  };
  
  export default LandingPage;