import React from 'react';
import './Footer.css';

const Footer = () => {
	return (
		<div className="footer">
			© 2024 جميع الحقوق محفوظة، تحت إشراف: د عايده نصر. المطورين:{' '}
			<a
				href="https://github.com/engmohamedtarek1"
				target="_blank"
				rel="noreferrer"
			>
				م/ محمد طارق
			</a>{' '}
			و{' '}
			<a
				href="https://github.com/ahmedeldamity"
				target="_blank"
				rel="noreferrer"
			>
				م/ أحمد الدماطي
			</a>
		</div>
	);
};

export default Footer;
