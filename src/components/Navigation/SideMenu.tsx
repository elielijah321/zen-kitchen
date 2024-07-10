import React, { useState } from 'react';
import './SideMenu.css';

import NestBox from "./icons/nest-box.png";
import Profile from "./icons/profile.png";
// import RabbitIcon from "./icons/Rabbit.png";
// import Money from "./icons/money.png";
import { BrowserRouter, Link, Route, Routes } from 'react-router-dom';
import Home from '../Home';

import DefendantsPage from '../Defendant/DefendantsPage';
import EditDefendant from '../Defendant/EditDefendant';
import ForgotPasswordPage from './Authentication/ForgotPassword';
import LoginPage from './Authentication/LoginPage';

const SideMenu: React.FC = () => {
  const [isOpen, setIsOpen] = useState(false);

  const toggleMenu = () => {
    setIsOpen(!isOpen);
  };

  const [activeIndex, setActiveIndex] = useState(0);

  const menuItems = 
  [
      { name: 'Home', icon: NestBox, path: '/home' },
      { name: 'Defendants', icon: Profile, path: '/Defendants' }
  ];

  const isAuthenticated = () => {
    const accessToken = sessionStorage.getItem('accessToken');
    return !!accessToken;
  };

  const handleLogout = () => {
    sessionStorage.clear();
    toggleMenu();
  };

  const navigateToPageIfAuthenticated = (component: JSX.Element) => {

    return isAuthenticated() ? component : <LoginPage />;
  }

  return (
    <>
      {
        isAuthenticated() && 
        (
          <div className="burger-menu" onClick={toggleMenu}>
          <div className={isOpen ? "burger-menu-icon open" : "burger-menu-icon"}>
            <div className="bar1"></div>
            <div className="bar2"></div>
            <div className="bar3"></div>
          </div>
        </div>
        )
      }

      <BrowserRouter>
          <Routes>
              <Route path="/" element={navigateToPageIfAuthenticated(<Home />)} />
              <Route path="/home" element={navigateToPageIfAuthenticated(<Home />)} />
              <Route path="/Defendants" element={navigateToPageIfAuthenticated(<DefendantsPage />)} />
              <Route path="/Defendant/:id" element={navigateToPageIfAuthenticated(<EditDefendant />)} />

              <Route path="/login" element={<LoginPage />} />
              <Route path="/forgot-password" element={<ForgotPasswordPage />} />
          </Routes>

          <div className={`overlay ${isOpen ? 'open' : ''}`} onClick={toggleMenu} />
          <div className={`menu ${isOpen ? 'open' : ''}`}>
            <h2 className='title'>Menu</h2>
            <ul className='navigation-ul'>
                {menuItems.map((item, index) => (
                        <>
                          <Link className={`link ${activeIndex === index ? 'active' : ''}`} to={item.path} onClick={toggleMenu}>
                              <li key={index} className={`list ${activeIndex === index ? 'active' : ''}`} onClick={() => setActiveIndex(index)}>
                                      <span className="icon">
                                          <img src={item.icon} className='icon' alt={item.name} />
                                      </span>
                                      <span className="text">{item.name}</span>
                                      {/* <span className="text">{item.name === "Sales" && farmOrders.length > 0 ? `Sales (${farmOrders.length})` : item.name}</span> */}
                              </li>
                          </Link>
                          {/* <br className='link-break' /> */}
                        </>
                ))}
            </ul>
            <div className="sticky-bottom">
              <ul className='navigation-ul'>
                <Link className={`link`} to="/login" onClick={handleLogout}>
                    <li className={`list`}>
                        <span className="text">Logout</span>
                    </li>
                </Link>
              </ul>
            </div>
          </div>
      </BrowserRouter>

    </>
  );
};

export default SideMenu;
