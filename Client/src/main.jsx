import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.jsx";
import "./styles/app.scss";
import { BrowserRouter } from "react-router-dom";
import AppContextProvider from "./components/AppContextProvider.jsx";
import { ChakraProvider } from "@chakra-ui/react";

export const serverLink = "http://localhost:8080/v1";

ReactDOM.createRoot(document.getElementById("root")).render(
    <AppContextProvider>
        <BrowserRouter>
            <ChakraProvider>
                <App />
            </ChakraProvider>
        </BrowserRouter>
    </AppContextProvider>
);
