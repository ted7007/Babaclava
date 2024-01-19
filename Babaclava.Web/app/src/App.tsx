import React from "react";
import { BrowserRouter as Router, Route, Routes, Navigate, RouterProvider, createBrowserRouter } from "react-router-dom";
import TypeBook from "./components/screens/type-book/TypeBook";

const router = createBrowserRouter([
  {
    path: ":bookId/type",
    element: <TypeBook />,
  },
  {
    path: "/catalog",
    element: <div>catalog</div>,
  },
  {
    path: "/*",
    element: <Navigate to="/catalog" />,
  },
]);

export const App: React.FC = () => {
  return (
    <>
      <RouterProvider router={router} />
    </>
  );
};
