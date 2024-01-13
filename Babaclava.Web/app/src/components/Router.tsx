import { BrowserRouter, Route, Routes } from "react-router-dom";

const Router = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<div>home</div>} path="/" />
        <Route element={<div>not found</div>} path="*" />
      </Routes>
    </BrowserRouter>
  );
};

export default Router;
