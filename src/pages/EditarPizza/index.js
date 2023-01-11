import React from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import './styles.css';
import { Link, useParams } from "react-router-dom";
import { FiCornerDownLeft, FiUserPlus } from 'react-icons/fi';

export default function EditarPizza() {

    const {pizzaId} = useParams();

    return (
        <div className="nova-pizza-container">
            <div className="content">
                <section className="form">
                    <FiUserPlus size='105' color='#17202a'/>
                    <h1>{pizzaId === '0'? 'Adicionar nova pizza' : 'Atualizar pizza'}</h1>
                    <Link className="back-link" to="/pizzas">
                        <FiCornerDownLeft size="25" color="#17202a"/>
                        Retornar
                    </Link>
                </section>
                <form>
                    <input placeholder="Nome"/>
                    <input placeholder="Temglutem"/>
                    <input placeholder="Preço"/>
                    <input placeholder="Descrição"/>
                    <button className="button" type="submit">{pizzaId === '0'? 'Adicionar' : 'Editar'}</button>
                </form>
            </div>
        </div>
    );
  }