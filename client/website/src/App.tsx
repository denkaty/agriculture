import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { RegisterView } from "./features/users/views/RegisterView/RegisterView";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/register" element={<RegisterView />} />
                {/* Add more routes here */}
            </Routes>
        </Router>
    );
}

export default App;
