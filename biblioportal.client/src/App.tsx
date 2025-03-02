import './App.css'
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import LayoutComponent from './components/Layout';
import Registration from './components/Registration';
import Login from './components/Login';


export function App() {

	return (
		<>
			<LayoutComponent>
				<Login />
			</LayoutComponent>
		</>
	);
}
export default App
