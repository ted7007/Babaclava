import { BrowserRouter, Route, Routes, Navigate } from "react-router-dom";
import TypeBook from "./screens/type-book/TypeBook";

const Router = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/:id/type" element={<TypeBook />} />
        <Route path="*" element={<Navigate to="/asdf1234/type" replace />} />
      </Routes>
    </BrowserRouter>
  );
};

export default Router;
