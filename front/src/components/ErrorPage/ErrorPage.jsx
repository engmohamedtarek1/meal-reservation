import React from 'react';
import './ErrorPage.css';

function ErrorPage() {
	// const error = useRouteError();
	// console.error(error);

	return (
		<div className="error-page">
			<h1>Oops!</h1>
			<p>Sorry, an unexpected error has occurred.</p>
			<a className="home" href="/">
				Go Home
			</a>
		</div>
	);
}

export default ErrorPage;
