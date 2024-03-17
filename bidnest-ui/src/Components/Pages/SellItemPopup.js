import React, { useState } from 'react';
import '../Styles/SellItemPopup.css';

const SellItemPopup = ({ onClose }) => {
  const [formData, setFormData] = useState({
    title: '',
    description: '',
    startDate: new Date().toISOString(),
    endDate: '',
    initialAmount: '',
    status: 'none',
    images: [],
  });

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleImageChange = (e) => {
    setFormData({ ...formData, images: e.target.files });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Add functionality to handle form submission
    // Call your API to submit the form data
    console.log(formData);
    // Close the popup
    onClose();
  };

  return (
    <div className="sell-item-popup">
      <div className="popup-container">
        <div className="popup-header">
          <h2>Sell Item</h2>
          <button className="close-btn" onClick={onClose}>
            Close
          </button>
        </div>
        <div className="popup-body">
          <form onSubmit={handleSubmit}>
            <label>Title:</label>
            <input
              type="text"
              name="title"
              value={formData.title}
              onChange={handleChange}
            />

            <label>Description:</label>
            <textarea
              name="description"
              value={formData.description}
              onChange={handleChange}
            ></textarea>

            <label>Start Date:</label>
            <input
              type="text"
              readOnly
              value={formData.startDate}
              name="startDate"
            />

            <label>End Date:</label>
            <input
              type="text"
              name="endDate"
              value={formData.endDate}
              onChange={handleChange}
            />

            <label>Initial Amount:</label>
            <input
              type="number"
              name="initialAmount"
              value={formData.initialAmount}
              onChange={handleChange}
            />

            <label>Status:</label>
            <select
              name="status"
              value={formData.status}
              onChange={handleChange}
            >
              <option value="none">None</option>
              <option value="live">Live</option>
            </select>

            <label>Images:</label>
            <input
              type="file"
              multiple
              name="images"
              onChange={handleImageChange}
            />

            <button type="submit">Submit</button>
            <button type="button" onClick={onClose}></button>
          </form>
        </div>
      </div>
    </div>
  );
};

export default SellItemPopup;
