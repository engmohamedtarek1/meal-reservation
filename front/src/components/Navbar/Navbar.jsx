import React, { useState } from 'react';
import './Navbar.css';
import { NavLink } from 'react-router-dom';

function Navbar() {
	const [clicked, setClicked] = useState(false);

	function handleClick() {
		setClicked(!clicked);
	}

	return (
		<>
			<div className="navbar">
				<div className="left">Tanta University</div>
				<div className="right">
					<ul id="menu" className={clicked ? '#menu active' : '#menu'}>
						<NavLink to="/">Home</NavLink>
						<NavLink to="/signup">Sign Up</NavLink>
						<NavLink to="/login">Login</NavLink>
					</ul>
				</div>
				<div id="mobile" onClick={handleClick}>
					<i className={clicked ? 'fas fa-times' : 'fas fa-bars'}></i>
				</div>
			</div>
		</>
	);
}

export default Navbar;
