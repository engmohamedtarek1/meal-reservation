import React, { useState } from 'react';
import './ResetPassword.css';
import email_icon from '../../images/email.png';
import password_icon from '../../images/password.png';
import axios from 'axios';

const ResetPassword = () => {
	const userData = JSON.parse(localStorage.getItem('userData'));

	const [success, setSuccess] = useState('');

	const [formData, setFormData] = useState({
		email: '',
		password: '',
		confirmPassword: '',
	});

	const handleChange = (e) => {
		const { name, value } = e.target;
		setFormData({ ...formData, [name]: value });
	};

	async function getNewToken() {
		await axios
			.post('/api/Account/resetpasswordtoken', {
				email: formData.email,
			})
			.then((response) => {
				userData.token = response.data.token;
				localStorage.setItem('userData', JSON.stringify(response.data));
			})
			.catch((error) => {
				setSuccess('No');
			});
	}

	async function sendData() {
		await getNewToken();
		const data = {
			email: formData.email,
			password: formData.password,
			confirmPassword: formData.confirmPassword,
			token: userData.token,
		};

		axios
			.post('/api/Account/resetpassword', data)
			.then((response) => {
				setSuccess('Yes');
				setTimeout(() => (window.location.href = '/login'), 3000);
			})
			.catch((error) => {
				setSuccess('No');
			});
	}

	return (
		<>
			<div className="resetForm">
				<div className="text-container">
					<div className="text">Reset Password</div>
					<div className="underline"></div>
				</div>
				<div className="inputs">
					{success === 'Yes' ? (
						<div className="success-message">
							<i className="fa-solid fa-check-double"></i> تم تغيير كلمة المرور
							بنجاح، جاري تحويلك إلى صفحة تسجيل الدخول خلال 3 ثواني.
						</div>
					) : success === 'No' ? (
						<div className="error-message">
							<i className="fa-solid fa-triangle-exclamation"></i> يوجد خطأ
							أثناء إرسال البيانات، يرجى التأكد من صحة البريد الإلكتروني وكتابة
							كلمة المرور بالطريقة الصحيحة.
						</div>
					) : (
						''
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
							placeholder="تعيين كلمة المرور الجديدة"
							onChange={handleChange}
						></input>
					</div>
					<div className="input">
						<img src={password_icon} alt=""></img>
						<input
							type="password"
							name="confirmPassword"
							placeholder="تأكيد كلمة المرور الجديدة"
							onChange={handleChange}
						></input>
					</div>
				</div>
				<div className="submit-container">
					<button type="submit" className="submit" onClick={sendData}>
						Reset Password
					</button>
				</div>
			</div>
		</>
	);
};

export default ResetPassword;
