import React from 'react';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faGavel } from '@fortawesome/free-solid-svg-icons';
import { faUser , faRightFromBracket} from '@fortawesome/free-solid-svg-icons';
import '../Styles/Header.css'; 
import { useState } from 'react';
import LoginPopup from './LoginPoup';
import variable from '../../Variable/variables';

const Header = () => {
    const [isLoginPopupOpen, setLoginPopupOpen] = useState(false);
    const [mode,setMode] = useState(true);
  const openLoginPopup = () => {
    setMode(true);
    setLoginPopupOpen(true);
  };
  const openSignUpPopup = () => {
    setMode(false);
    setLoginPopupOpen(true);
  };
  const closeLoginPopup = () => {
    setLoginPopupOpen(false);
  };
  const logout = () => {
    sessionStorage.clear();
    window.location.reload();
  }
  return (
    <header>
      <div className="left-section">
        <div className="logo-container">
          <span className="bidnest-text">BidNest</span>
          <FontAwesomeIcon icon={faGavel} className="gavel-icon" />
        </div>
      </div>
      <div className="right-section">
        <nav>
          <ul>
            <li><Link to="/bid">Bid</Link></li>
            <li><Link to="/sell">Sell</Link></li>
            <li><Link to="/contact">Contact</Link></li>
            { variable.isuserloggedin ?<>
                <li className="login-button">{variable.UserName}<FontAwesomeIcon icon={faUser} className="user-icon"/></li>
                <li className="signup-button" onClick={logout} >Logout<FontAwesomeIcon icon={faRightFromBracket} className="user-icon"/></li>
            </>:<>
            <li className="login-button" onClick={openLoginPopup}>Login</li>
            <li><button className="signup-button" onClick={openSignUpPopup}>Sign Up</button></li>
            </>
            }
          </ul>
        </nav>
      </div>
      {isLoginPopupOpen && <LoginPopup onClose={closeLoginPopup} Mode={mode}/>}
    </header>
  );
};

export default Header;
