import './App.css'
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import LayoutComponent from './components/Layout';
import Registration from './components/Registration';
import Login from './components/Login';


export function App() {

	return (
		<Router>
			<LayoutComponent>
				<Routes>
					<Route index element={<Login />} />
					<Route path="/login" element={<Login />} />
					<Route path="/register" element={<Registration />} />
				</Routes>
			</LayoutComponent>
		</Router>
	);
}
export default App
