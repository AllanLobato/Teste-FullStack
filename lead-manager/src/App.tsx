import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import Invited from './pages/Invited';
import Accepted from './pages/Accepted';
import Tabs from './components/Tabs';

function App() {
  return (
    <Router>
      <Tabs />
      <Routes>
        <Route path="/invited" element={<Invited />} />
        <Route path="/accepted" element={<Accepted />} />
        <Route path="*" element={<Navigate to="/invited" />} />
      </Routes>
    </Router>
  );
}

export default App;

