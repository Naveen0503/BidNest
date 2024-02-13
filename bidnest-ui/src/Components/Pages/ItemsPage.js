import React, { useEffect , useState } from 'react';
import '../Styles/ItemsPage.css';
import axios from 'axios';
import variable from '../../Variable/variables';
import 'bootstrap/dist/css/bootstrap.min.css';
import Header from '../Common/Header';

const ItemsPage = () => {
  const [items, setItems] = useState([]);

  useEffect(() => {
    axios.get(variable.Base_Api_Url + 'api/ItemImages')
    .then((response) => {
      console.log(response.data);
      setItems(response.data);
    })
  },[])

  return (
    <>
    <Header/>
    <div className="items-container">
      <div className="item-card">
        <div className="carousel-container">
          <div id="itemCarousel" className="carousel slide" data-bs-ride="carousel">
            <div className="carousel-inner">
              {items.map((item ,index) => (
            <div key={index} className={`carousel-item ${index === 0 ? 'active' : ''}`}>
              <img src={`data:image/png;base64, ${item.imageData}`} className="d-block w-100" alt={`Auction Slide ${index}`} />
            </div>
          ))}
            </div>
          </div>
        </div>
        <div className="item-details">
          <h3>Item Name</h3>
          <p>Description: Lorem ipsum dolor sit amet...</p>
          <p>Time Left: 3 days</p>
          <p>Starting Bid: $50</p>
          <p>Current Bid: $75</p>
          <button className="login-button">Place Bid</button>
        </div>
      </div>
      <div className="item-card">
        <div className="carousel-container">
          <div id="itemCarousel" className="carousel slide" data-bs-ride="carousel">
            <div className="carousel-inner">
              {items.map((item ,index) => (
            <div key={index} className={`carousel-item ${index === 0 ? 'active' : ''}`}>
              <img src={`data:image/png;base64, ${item.imageData}`} className="d-block w-100" alt={`Auction Slide ${index}`} />
            </div>
          ))}
            </div>
          </div>
        </div>
        <div className="item-details">
          <h3>Item Name</h3>
          <p>Description: Lorem ipsum dolor sit amet...</p>
          <p>Time Left: 3 days</p>
          <p>Starting Bid: $50</p>
          <p>Current Bid: $75</p>
          <button className="signup-button">Place Bid</button>
        </div>
      </div>
      <div className="item-card">
        <div className="carousel-container">
          <div id="itemCarousel" className="carousel slide" data-bs-ride="carousel">
            <div className="carousel-inner">
              {items.map((item ,index) => (
            <div key={index} className={`carousel-item ${index === 0 ? 'active' : ''}`}>
              <img src={`data:image/png;base64, ${item.imageData}`} className="d-block w-100" alt={`Auction Slide ${index}`} />
            </div>
          ))}
            </div>
          </div>
        </div>
        <div className="item-details">
          <h3>Item Name</h3>
          <p>Description: Lorem ipsum dolor sit amet...</p>
          <p>Time Left: 3 days</p>
          <p>Starting Bid: $50</p>
          <p>Current Bid: $75</p>
          <button className="btn btn-primary">Place Bid</button>
        </div>
      </div>
       <div className="item-card">
        <div className="carousel-container">
          <div id="itemCarousel" className="carousel slide" data-bs-ride="carousel">
            <div className="carousel-inner">
              {items.map((item ,index) => (
            <div key={index} className={`carousel-item ${index === 0 ? 'active' : ''}`}>
              <img src={`data:image/png;base64, ${item.imageData}`} className="d-block w-100" alt={`Auction Slide ${index}`} />
            </div>
          ))}
            </div>
          </div>
        </div>
        <div className="item-details">
          <h3>Item Name</h3>
          <p>Description: Lorem ipsum dolor sit amet...</p>
          <p>Time Left: 3 days</p>
          <p>Starting Bid: $50</p>
          <p>Current Bid: $75</p>
          <button className="btn btn-primary">Place Bid</button>
        </div>
      </div>
    </div>
    </>
  );
};

export default ItemsPage;
