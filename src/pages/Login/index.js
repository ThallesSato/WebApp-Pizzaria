import React, { useState } from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import './styles.css';
import api from "../../services/api";


export default function Login() {

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    async function login(event){
        event.preventDefault();

        const data = {username,password};

        try {
            const response  = await api.post("api/account/loginuser",data);

            localStorage.setItem('username',username);
            localStorage.setItem('token',response.data.token);
            localStorage.setItem('expiration',response.data.expiration);

            
        } catch (error) {
            alert('o login falhou')
        }
    }

    return (
        <div className="login-container">
            <section className="form">
                <form onSubmit={login}>
                    <h1>Login</h1>
                    <input placeholder="Username"
                        value={username}
                        onChange={e=>setUsername(e.target.value)}
                    />
                    <input type="password" placeholder="Password"
                        value={password}
                        onChange={e=>setPassword(e.target.value)}
                    />
                    <input class="button" type="submit"></input>
                </form>
            </section>
        </div>
    );
  }