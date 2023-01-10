import React from "react";
import { createBrowserRouter, RouterProvider} from "react-router-dom";
import Login from "./pages/Login";

const router = createBrowserRouter([
    {
      path: "/",
      element: <Login/>,
    },
  ]);

export default function Routes(){
    return(
        <React.StrictMode>
            <RouterProvider router={router} />
        </React.StrictMode>
    );
}