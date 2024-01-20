import React from "react";
import {
  BrowserRouter as Router,
  Route,
  Routes,
  Navigate,
  RouterProvider,
  createBrowserRouter,
} from "react-router-dom";
import TypeBook from "./components/screens/type-book/TypeBook";
import { Header } from "./components/Header/Header";
import { Catalog } from "./components/screens/catalog/Catalog";

const router = createBrowserRouter([
  {
    path: ":bookId/type",
    element: <TypeBook />,
  },
  {
    path: "/catalog",
    element: <Catalog />,
  },
  {
    path: "/*",
    element: <Navigate to="/catalog" />,
  },
]);

export const App: React.FC = () => {
  return (
    <>
      <Header />
      <RouterProvider router={router} />
    </>
  );
};
