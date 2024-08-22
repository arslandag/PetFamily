import '../assets/SideBar.css'

export function SideBar() {
    return (
    <>
    <section className='sidebar'>
      <div className='navigationpanel'>
        <div className='allpets'>
          <button className='petsbutton'>
            <p> Все животные</p>
          </button>
        </div>
        <div className='allvolunteer'>
          <p>Все волонтеры</p>
        </div>
        <div className='news'>
          <p>Новости и объявления</p>
        </div>
      </div>
    </section>
    </>
)}