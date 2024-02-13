import './App.css';
import {BrowserRouter , Routes , Route} from "react-router-dom"
import Home from './Components/Pages/Home';
import ItemsPage from './Components/Pages/ItemsPage';



function App() {
  return (
    <div className="App">
    <BrowserRouter>
    <Routes>
      <Route path='/' element={<Home/>}/>
      <Route path='/Bid' element={<ItemsPage/>}/>
    </Routes>
    </BrowserRouter>
    </div>
  );
}

export default App;
