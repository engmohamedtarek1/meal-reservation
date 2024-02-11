import React, { useState } from 'react';
import './Navbar.css';
import { NavLink } from 'react-router-dom';
import tu from '../../images/tu.png';
import dtu from '../../images/dtu.png';

function Navbar() {
	const [clicked, setClicked] = useState(false);
	const userData = JSON.parse(localStorage.getItem('userData'));

	function handleClick() {
		setClicked(!clicked);
	}

	function handleLogout() {
		localStorage.removeItem('userData');
		window.location.href = '/';
	}

	return (
		<>
			<div className="navbar">
				<div className="left">
					<img src={tu} alt="logo" className="logo"></img>
				</div>
				<div className="right">
					<ul id="menu" className={clicked ? '#menu active' : '#menu'}>
						{!userData ? (
							<NavLink to="/signup">Sign Up</NavLink>
						) : (
							<NavLink to="/profile">Profile</NavLink>
						)}
						{!userData ? (
							<NavLink to="/login">Login</NavLink>
						) : (
							<div className="logout" onClick={handleLogout}>
								Log Out
							</div>
						)}
					</ul>
					<img src={dtu} alt="logo" className="logo"></img>
				</div>
				<div id="mobile" onClick={handleClick}>
					<i className={clicked ? 'fas fa-times' : 'fas fa-bars'}></i>
				</div>
			</div>
		</>
	);
}

export default Navbar;
