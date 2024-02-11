import React, { useState } from 'react';
import './Profile.css';
import axios from 'axios';
import StudentsCard from './StudentsCard/StudentsCard';

const Profile = () => {
	const userData = JSON.parse(localStorage.getItem('userData'));
	const [success, setSuccess] = useState('');
	const hasAdmin = userData.role.includes('Admin');

	function handleClick() {
		axios
			.post(
				'/api/Meal',
				{},
				{
					headers: {
						Authorization: `Bearer ${userData.token}`,
					},
				}
			)
			.then((response) => {
				setSuccess('Yes');
			})
			.catch((error) => {
				setSuccess('No');
			});
	}

	return (
		<>
			<div className="profile">
				<h1>
					،أهلاً <span>{userData.name}</span>
				</h1>
				{!hasAdmin ? (
					<>
						<h3 className="profile-text">
							لحجز الوجبات يرجى الضغط على هذا الزر
						</h3>
						<button type="submit" className="submit hagz" onClick={handleClick}>
							حجز الوجبة
						</button>
					</>
				) : (
					''
				)}
				{success === 'Yes' ? (
					<div className="success-message">
						<i className="fa-solid fa-check-double"></i> تم حجز الوجبة بنجاح.
					</div>
				) : success === 'No' ? (
					<div className="error-message">
						<i className="fa-solid fa-triangle-exclamation"></i> لقد حجزت وجبة
						بالفعل.
					</div>
				) : (
					''
				)}
				{hasAdmin && <StudentsCard token={userData.token} />}
			</div>
		</>
	);
};

export default Profile;
