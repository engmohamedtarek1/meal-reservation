import React, { useState } from 'react';
import './LoginForm.css';
import email_icon from '../../images/email.png';
import password_icon from '../../images/password.png';
import axios from 'axios';
import { Link } from 'react-router-dom';

function LoginForm() {
	const [formData, setFormData] = useState({
		email: '',
		password: '',
	});

	const [error, setError] = useState(false);

	const handleChange = (e) => {
		const { name, value } = e.target;
		setFormData({ ...formData, [name]: value });
	};

	const fetchData = async () => {
		const data = formData;

		axios
			.post('/api/account/login', data)
			.then((response) => {
				localStorage.setItem('userData', JSON.stringify(response.data));
			})
			.then((response) => {
				window.location.href = '/profile';
			})
			.catch((error) => {
				setError(true);
			});
	};

	return (
		<>
			<div className="loginForm">
				<div className="text-container">
					<div className="text">Login</div>
					<div className="underline"></div>
				</div>
				<div className="inputs">
					{error && (
						<div className="error-message">
							<i className="fa-solid fa-triangle-exclamation"></i> يوجد خطأ في
							البريد الإلكتروني أو كلمة المرور، يرجى ملأ الإستمارة بالشكل
							الصحيح.
						</div>
					)}
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
						<img src={password_icon} alt=""></img>
						<input
							type="password"
							name="password"
							placeholder="كلمة المرور"
							onChange={handleChange}
						></input>
					</div>
				</div>
				<p className="reset-password">
					<Link to="/reset-password">Forgot your password? Reset it.</Link>
				</p>
				<p className="signup-button">
					<Link to="/signup">Doesn't have an account? Create new one.</Link>
				</p>
				<div className="submit-container">
					<button type="submit" className="submit" onClick={fetchData}>
						Login
					</button>
				</div>
			</div>
		</>
	);
}

export default LoginForm;
