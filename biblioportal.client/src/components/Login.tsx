import styled from "styled-components";
import { login } from "../services/AuthServices";
import { useFormik } from 'formik';

const LoginContainer = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 70vh;
`;
const FormWrapper = styled.div`
  width: 100%;
  max-width: 340px;
  background-color: light-dark(#fff, #242424);
  padding: 30px;
  border-radius: 8px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
`;
const LoginTitle = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
`;
const FormInput = styled.input`
    margin-bottom:16px;
    width:100%;
    border:#d9d9d9 1px solid;
    padding:7px 11px;
    font-size:16px;
    border-radius:8px;
    box-sizing: border-box;
    text-overflow: ellipsis;
  &::placeholder {
     color: #b9b9b9  ;
     font-family: Inter, system-ui, Avenir, Helvetica, Arial, sans-serif;
  }
    &:focus {
        border-color:#1677ff;
        box-shadow:0 0 0 2px rgba(5, 145, 255, 0.1);
        outline:0;
    }
    &:hover {
        border-color:#1677ff;
    }
`;
const PrimaryBtn = styled.button`
    background: #1677ff;
    color: #fff;
    width: 100%;
    &:hover {
        background: #4096ff;
    }
`;

function Login() {
    interface LoginValues {
            email: string;
            password: string;
        }
    const formik = useFormik({
    
        initialValues: {
            email: "",
            password: ""
        },
        onSubmit: async (values: LoginValues) => {
            try {
                const loginData = {
                    ...values,
                    twoFactorCode: "string",
                    twoFactorRecoveryCode: "string"
                };
                const response = await login(loginData);
                console.log(`Response login ${JSON.stringify(response.data)}`);
            } catch (error) { ; }
        }
    });
  return (
      <LoginContainer>
          <FormWrapper>
              <LoginTitle>
                  <h2>Login</h2>
              </LoginTitle>
              <form onSubmit={formik.handleSubmit}>
                <label htmlFor="email">Email</label>
                  <FormInput name="email" type="email" placeholder="Enter your email"
                      onChange={formik.handleChange}
                      onBlur={formik.handleBlur}
                      value={formik.values.email} />
                <label htmlFor="password">Password</label>
                  <FormInput name="password" type="password" placeholder="Enter your password"
                      onChange={formik.handleChange}
                      onBlur={formik.handleBlur}
                      value={formik.values.password}/>
                  <PrimaryBtn type="submit" disabled={formik.isSubmitting}>
                      {formik.isSubmitting ? 'Connexion...' : 'Se connecter'}
                  </PrimaryBtn>
              </form>
          </FormWrapper>
      </LoginContainer>
  );
}

export default Login;