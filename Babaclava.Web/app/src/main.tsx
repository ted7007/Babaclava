import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import { App } from "./App.tsx";
import {
  Navigate,
  RouterProvider,
  createBrowserRouter,
} from "react-router-dom";
import TypeBook from "./components/screens/type-book/TypeBook.tsx";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
