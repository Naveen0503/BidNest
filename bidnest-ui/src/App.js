import './App.css';
import {BrowserRouter , Routes , Route} from "react-router-dom"
import Home from './Components/Pages/Home';
import ItemsPage from './Components/Pages/ItemsPage';
import Header from './Components/Common/Header';
import NavBar from './Components/Common/NavBar';
import variable from './Variable/variables';



function App() {
  return (
    <div className="App">
    <BrowserRouter>
    <Header/>
    {
      variable.isuserloggedin ?
    <NavBar/>
    : null
    }
    <Routes>
      <Route path='/' element={<Home/>}/>
      <Route path='/Bid' element={<ItemsPage/>}/>
    </Routes>
    </BrowserRouter>
    </div>
  );
}

export default App;
