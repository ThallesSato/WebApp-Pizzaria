import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import './styles.css';

export default function Login() {
    return (
        <div className="login-container">
            <section className="form">
                <form>
                    <h1>Login</h1>
                    <input placeholder="Username"/>
                    <input type="password" placeholder="Password"/>
                    <input class="button" type="submit"></input>
                </form>
            </section>
        </div>
    );
  }