import SuperHero from "./SuperHero";

const SuperHeroList = ({ superheroes, handleDelete } ) => {
    console.log(superheroes)
    return (
        <div className="superHeroes">
            {superheroes.map(superhero => (
                <SuperHero superhero={ superhero } handleDelete={handleDelete} key={superhero.id}/>
            ))}
        </div>
    )
}

export default SuperHeroList