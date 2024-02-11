import React, { useState } from 'react';
import './SignupForm.css';
import user_icon from '../../images/person.png';
import email_icon from '../../images/email.png';
import password_icon from '../../images/password.png';
import axios from 'axios';

function SignupForm() {
	const [formData, setFormData] = useState({
		SSN: '',
		name: '',
		email: '',
		password: '',
		ConfirmPassword: '',
	});

	const [error, setError] = useState(false);

	const handleChange = (e) => {
		const { name, value } = e.target;
		setFormData({ ...formData, [name]: value });
	};

	const fetchData = async () => {
		const data = formData;

		axios
			.post('/api/account/register', data)
			.then((response) => {
				window.location.href = '/login';
			})
			.catch((error) => {
				setError(true);
			});
	};

	return (
		<>
			<div className="signupForm">
				<div className="text-container">
					<div className="text">Sign Up</div>
					<div className="underline"></div>
				</div>
				<div className="inputs">
					{error && (
						<div className="error-message">
							<i className="fa-solid fa-triangle-exclamation"></i> يوجد خطأ في
							البيانات، يرجى تعبئة الإستمارة بالشكل الصحيح.
						</div>
					)}

					<div className="input">
						<img src={user_icon} alt=""></img>
						<input
							type="text"
							name="name"
							placeholder="الاسم الرباعي"
							onChange={handleChange}
						></input>
					</div>
					<div className="input">
						<img src={email_icon} alt=""></img>
						<input
							type="email"
							name="email"
							placeholder="البريد الإلكتروني"
							onChange={handleChange}
						></input>
					</div>
					<div className="input">
						<i className="fa-solid fa-id-card id-icon"></i>
						<input
							type="text"
							name="SSN"
							placeholder="الرقم القومي"
							onChange={handleChange}
						></input>
					</div>
					<div className="input">
						<img src={password_icon} alt=""></img>
						<input
							type="password"
							name="password"
							placeholder="كلمة المرور"
							onChange={handleChange}
						></input>
					</div>
					<div className="input">
						<img src={password_icon} alt=""></img>
						<input
							type="password"
							name="ConfirmPassword"
							placeholder="تأكيد كلمة المرور"
							onChange={handleChange}
						></input>
					</div>
				</div>
				<button type="submit" className="submit" onClick={fetchData}>
					Sign Up
				</button>
			</div>
		</>
	);
}

export default SignupForm;
