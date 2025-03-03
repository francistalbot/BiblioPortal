import './App.css'
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import LayoutComponent from './components/Layout';
import Registration from './components/Registration';
import Login from './components/Login';


export function App() {

	return (
		<>
			<Router>
				<Routes>
					<Route index element={<Login />} />
					<Route path="/login" element={<Login />} />
					<Route path="/register" element={<Registration />} />
				</Routes>
			</Router>
			<LayoutComponent>
				<Login />
			</LayoutComponent>
		</>
	);
}
export default App
