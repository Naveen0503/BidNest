import {React , useState} from 'react';
import SellItemPopup from '../Pages/SellItemPopup';
import '../Styles/NavBar.css';

const NavBar = () => {
    const [isSellItemPopupOpen, setSellItemPopupOpen] = useState(false);

    const openSellItemPopup = () => {
        setSellItemPopupOpen(true);
      };
    
      const closeSellItemPopup = () => {
        setSellItemPopupOpen(false);
      };
  return (
    <>
    <nav className="navbar">
      <ul className="nav-list">
        <li className="nav-item"><a href='/'>Home</a></li>
        <li className="nav-item"><a href='/bid'>Active Auctions</a></li>
        <li className="nav-item"><a href='/'>Bidding History</a></li>
        <li className="nav-item"><a href='/#' onClick={openSellItemPopup}>Create New Auction</a></li>
      </ul>
    </nav>
    {isSellItemPopupOpen && <SellItemPopup onClose={closeSellItemPopup} />}
    </>
  );
};

export default NavBar;
