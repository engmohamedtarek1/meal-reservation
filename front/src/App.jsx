import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Navbar from './components/Navbar/Navbar';
import SignupForm from './components/SignupForm/SignupForm';
import LoginForm from './components/LoginForm/LoginForm';
import ErrorPage from './components/ErrorPage/ErrorPage';
import Profile from './components/Profile/Profile';
import axios from 'axios';
import ResetPassword from './components/ResetPassword/ResetPassword';
import Home from './components/Home/Home';
import Footer from './components/Footer/Footer';

export default function App() {
	axios.defaults.baseURL = 'https://localhost:5001';
	return (
		<Router>
			<Navbar />
			<Routes>
				<Route path="/" element={<Home />} />
				<Route path="/login" element={<LoginForm />} />
				<Route path="/signup" element={<SignupForm />} />
				<Route path="/profile" element={<Profile />} />
				<Route path="/reset-password" element={<ResetPassword />} />
				<Route path="*" element={<ErrorPage />} />
			</Routes>
			<Footer />
		</Router>
	);
}
