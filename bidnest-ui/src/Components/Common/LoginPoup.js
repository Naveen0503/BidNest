import React, { useState } from 'react';
import '../Styles/LoginPopup.css'; 
import axios from 'axios'
import variable from '../../Variable/variables';
import { useNavigate } from 'react-router-dom';

const LoginPopup = (props) => {
  const [isLoginMode, setLoginMode] = useState(props.Mode);
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [email,setEmail] = useState('');
  const navigate = useNavigate();

  const handleToggleSwitch = () => {
    setLoginMode(!isLoginMode);
  };

  const handleFormSubmit = (e) => {
    e.preventDefault();
    let payload ={
        "userName": username,
        "password": password
      };
    axios.post(variable.Base_Api_Url+"api/Login",payload)
    .then((res)=>{
        if(res.data !== "User Not found"){
         sessionStorage.setItem('token', res.data.token);
         sessionStorage.setItem('username',res.data.username);
         navigate('/Bid');
         window.location.reload();
        }
        else {

        }
        
    })
    .catch((err)=>{
        console.error(err);
    });
    props.onClose();
  };

  return (
    <div className="login-popup">
      <div className="login-popup-content">
        <div  className='toggle-section'>
        <div className="toggle-switch">
          <span className={isLoginMode ? 'active' : ''} onClick={handleToggleSwitch}>Login</span>
          <span className={!isLoginMode ? 'active' : ''} onClick={handleToggleSwitch}>Signup</span>
        </div>
        </div>
        <form onSubmit={handleFormSubmit}>
            {isLoginMode ? <>
          <div className="input-container">
            <input type="text" placeholder="Username/Email" value={username} onChange={(e) => setUsername(e.target.value)}/>
          </div>
          <div className="input-container">
            <input type="password" placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)} />
          </div>
          </>
          :<>
          <div className="input-container">
            <input type="text" placeholder="Email" value={email} onChange={(e) => setEmail(e.target.value)}/>
          </div>
          <div className="input-container">
            <input type="text" placeholder="Username" value={username} onChange={(e) => setUsername(e.target.value)} />
          </div>
          <div className="input-container">
            <input type="password" placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)}/>
          </div>
          </>
            }
          <div className="button-section">
          <button type="submit">{isLoginMode ? 'Login' : 'Signup'}</button>
          <button onClick={props.onclose}>Cancel</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default LoginPopup;
