const Home = () => {
	const userData = JSON.parse(localStorage.getItem('userData'));

	userData
		? (window.location.href = '/profile')
		: (window.location.href = '/login');
	return {};
};

export default Home;
