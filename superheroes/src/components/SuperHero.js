const SuperHero = ({ superhero, handleDelete }) => {

    return (
        <div className="superHero-preview">
            <p>Hey</p>
            <h2>{ superhero.name}</h2>
            <p>Real name: { superhero.firstName } { superhero.lastName }</p>
            <button onClick={() => handleDelete(superhero.id)}>Delete</button>
        </div>
    )
}

export default SuperHero