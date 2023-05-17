import React from "react";
import { createBrowserRouter, RouterProvider} from "react-router-dom";
import Login from "./pages/Login";
import Pizzas from "./pages/Pizzas";
import EditarPizza from "./pages/EditarPizza";

const router = createBrowserRouter([
    {
      path: "/",
      element: <Login/>,
    },
    {
      path: "/pizzas",
      element: <Pizzas/>,
    },
    {
      path: "/pizzas/editar/:pizzaId",
      element: <EditarPizza/>,
    }
  ]);

export default function Routes(){
    return(
        <React.StrictMode>
            <RouterProvider router={router} />
        </React.StrictMode>
    );
}