import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import './styles.css';
import { Link } from "react-router-dom";
import { FiEdit, FiUserX, FiXCircle } from 'react-icons/fi';

export default function Pizzas() {
    return (
        <div className="pizza-container">
            <header>
                <span>Bem-vindo, <strong>ioii</strong>!</span>
                <Link className="button" to="editar/0">Nova pizza</Link>
                <button type="button"><FiXCircle size='35'/></button>
            </header>
            <form>
                <input type='text' placeholder="Nome"/>
                <button type="button" class="button">Filtrar pizza por nome</button>
            </form>
            <h1>Pizzas</h1>
            <ul>
                <li>
                    <b>Nome: </b>aaa <br/><br/>
                    <b>Descrição: </b>aaa <br/><br/>
                    <b>Preço: </b>aaa <br/><br/>
                    <button type="button"><FiEdit size="25"/></button>
                    <button type="button"><FiUserX size="25"/></button>
                </li>
            </ul>
        </div>
    );
  }