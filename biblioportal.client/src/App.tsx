import './App.css'
import Header from './components/Header';
import styled from "styled-components";
import Registration from './components/Registration';

const MainStyled = styled.main`
	min-height:85vh;
	padding: 20px;
	background-color: light-dark(#fbfbfb, #202020);
`;

export function App() {

	return (
		<>
			<Header />
			<MainStyled>
				<Registration/>
			</MainStyled>
		</>
	);
}
export default App
