import styled from "styled-components";

const NavigationList = styled.ul`
	
	  list-style-type: none;
	  margin: 0;
	  padding: 0;
	  gap: 20px;
	  color: #000;
	  li {
		  margin: 0 10px;
		  display: inline-block;
	  };
`;
const NavigationLink = styled.a`
	
	display: block;
	color:darkslateblue;
	font-size: 17px;
	font-weight: bold;
	&:hover {
	background-color: none;
  }
`;
const LogoContainer = styled.div`
	display: flex;
	color: #000 ;
	align-items: center;
	cursor: pointer;
	font-size: 26px;
	font-weight: bold;
	gap: 10px;
	svg {
		height: 55px;
		width: 55px;
		fill: #fff;
	}
`;
const NavBar = styled.nav`
	
	display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 0 20px;
  background-color:rgb(213, 235, 255);
`;
export function Header() {
  return (

	  <header>
		  <NavBar>
			  <LogoContainer>
				  <svg version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg"
					  viewBox="0 0 511.997 511.997" >
					  <circle style={{ fill: "#00447D" }} cx="255.998" cy="255.998" r="255.998" />
					  <path style={{ fill: "#062964" }} d="M291.09,509.595c113.065-15.503,202.589-104.821,218.404-217.786L300.525,82.842l-7.044,59.099
								l-70.554-70.554l-6.289,45.557l45.719,86.393L159.75,241.783l67.178,67.178l-45.342,18.154l46.043,46.043l-10.99,61.986	L291.09,509.595z"/>
					  <polygon style={{ fill: "#E30033" }} points="330.415,241.781 181.585,327.114 181.585,270.224 330.415,184.893 " />
					  <polygon style={{ fill: "#C90236" }} points="330.415,184.893 256,227.557 256,284.448 330.415,241.781 " />
					  <path style={{ fill: "#FFFFFF" }} d="M284.444,348.408V163.601c16.199-9.692,27.051-27.401,27.051-47.652
								c0-18.254-8.818-34.449-22.423-44.563v43.721l-16.536,21.581h-33.073l-16.537-21.581V71.386
								c-13.605,10.114-22.423,26.308-22.423,44.563c0,20.251,10.85,37.962,27.051,47.652v184.807c-16.199,9.69-27.051,27.401-27.051,47.65
								c0,18.256,8.818,34.449,22.423,44.564v-43.721l16.536-21.581h33.073l16.536,21.581v43.721
								c13.605-10.114,22.423-26.307,22.423-44.563C311.496,375.809,300.644,358.099,284.444,348.408z"/>
					  <path style={{ fill: "#D0D1D3" }} d="M284.444,348.408V163.601c16.199-9.692,27.051-27.401,27.051-47.652
								c0-18.254-8.818-34.449-22.423-44.563v43.721l-16.536,21.581h-16.536v238.63h16.536l16.537,21.581v43.721
								c13.605-10.112,22.423-26.307,22.423-44.563C311.496,375.809,300.644,358.099,284.444,348.408z"/>
					  <polygon style={{ fill: "#FF6178" }} points="330.415,241.781 159.75,241.781 102.861,184.893 330.415,184.893 " />
					  <rect x="255.998" y="184.888" style={{ fill: "#FF0647" }} width="74.421" height="56.889" />
					  <polygon style={{ fill: "#FF6178" }} points="181.585,270.224 352.25,270.224 409.139,327.114 181.585,327.114 " />
					  <polygon style={{ fill: "#FF0647" }} points="352.25,270.224 256,270.224 256,327.114 409.139,327.114 " />
				  </svg>
				  Biblio
			  </LogoContainer>
			  <NavigationList>
				  <li><NavigationLink href="#">Login</NavigationLink></li>
				  <li><NavigationLink href="#">Register</NavigationLink></li>
			  </NavigationList>
		  </NavBar>
	  </header>
  );
}

export default Header;