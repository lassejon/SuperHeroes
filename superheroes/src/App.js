import { useState, useEffect } from 'react'
import SuperHeroes from './components/SuperHeroList'
import SuperHeroFetch from "./services/SuperHeroFetch";
import './App.css';
import superHeroFetch from "./services/SuperHeroFetch";

function App() {

    const [superHeroes, setSuperHeroes] = useState(null)

    useEffect(() => {
        superHeroFetch
            .getAll()
            .then(initialSuperHeroes => {
                setSuperHeroes(initialSuperHeroes)
                console.log("then", initialSuperHeroes)
            })
            .catch(error => {
                console.log("catch", error)
            })
    }, [])

    const handleDelete = (id) => {
        superHeroFetch.remove(id)
        setSuperHeroes(superHeroes.filter(s => s.id !== id))
    }

    return (
    <div className="App">
      <header className="App-header">
        <p>Hey there!</p>
      </header>
        {superHeroes && <SuperHeroes superheroes={superHeroes} handleDelete={handleDelete}/>}
    </div>
  );
}

export default App;
