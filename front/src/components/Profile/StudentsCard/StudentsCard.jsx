import React, { useEffect, useState } from 'react';
import './StudentsCard.css';
import axios from 'axios';
import { DataGrid } from '@mui/x-data-grid';

const StudentsCard = ({ ssn, name, email, date, token }) => {
	const [studentsData, setStudentsData] = useState(null);

	useEffect(
		function fetchData() {
			axios
				.get('/api/meal', {
					headers: {
						Authorization: `Bearer ${token}`,
					},
				})
				.then(async (response) => {
					await setStudentsData(response.data);
				})
				.catch((error) => {
					console.log(error);
				});
		},
		[token]
	);

	const columns = [
		{
			field: 'studentSSN',
			headerName: 'الرقم القومي',
			width: 180,
			type: 'number',
		},
		{ field: 'studentName', headerName: 'الاسم', width: 180 },
		{ field: 'studentEmail', headerName: 'الايميل', width: 235 },
		{ field: 'bookingDate', headerName: 'التاريخ', width: 230 },
	];

	const rows = studentsData || [];

	return (
		<>
			<div className="students-card">
				<div className="table">
					<DataGrid
						rows={rows}
						columns={columns}
						initialState={{
							pagination: {
								paginationModel: { page: 0, pageSize: 5 },
							},
						}}
						pageSizeOptions={[5]}
					/>
				</div>
			</div>
		</>
	);
};

export default StudentsCard;
