import '../assets/Header.css'

export function Header(){
    return (
    <>
    <section className='header'>      
      <div className='top-bar'>
          <div className='iconField'>
            <img src=".\icon.png" className='imageCat'/>
            <h1>PetFamily</h1>
          </div>
          <div className='searchField'>
            <img src=".\search.svg" className='imageSearch'/>
            <input className='inputSearch' placeholder='Search'></input>
          </div>
          <div className='userField'>
            <img src=".\user.svg" className='imageUser'/>
          </div>
      </div>
    </section>
    </>
)}