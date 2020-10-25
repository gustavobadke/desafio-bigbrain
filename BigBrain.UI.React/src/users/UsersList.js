import { Component } from "react";

import ItemUsersList from './components/ItemUsersList'

export default class UsersList extends Component {

    constructor(props) {
        super(props)

        this.state = {
            searchName: '',
            users: []
        }
    }
         
    componentDidMount() {
        this.loadUsers()
    }

    render() {
        return (<section className="container">
            <h1>Desafio BigBrain :: Usuarios</h1>
            <hr />

            <div className="card border-secondary mb-3">
                <div className="card-header">Filtro</div>
                <div className="card-body text-secondary">
                    <form onSubmit={this.handlerSubmit.bind(this)}>
                        <div className="row">
                            <div className="col">
                                <input id="Searchname" name="SearchName" type="text" placeholder="Buscar por nome" className="form-control"
                                    onChange={this.handlerSearchName.bind(this)} value={this.state.searchName} />
                            </div>
                            <div className="col-auto">
                                <button type="submit" className="btn btn-primary">Buscar</button>
                                &nbsp;
                                {this.state.searchName &&
                                    <button type="button" className="btn btn-danger" onClick={this.handlerClean.bind(this)}>Limpar Busca</button>}

                            </div>
                        </div>
                    </form>
                </div>
            </div>

            <div className="row">
                {this.state.users.map(user =>
                    <ItemUsersList key={user.displayName} displayName={user.displayName} mail={user.mail}></ItemUsersList>)}

                {!this.state.users.length &&
                    <div className="col"><div className="alert alert-info text-center">Carregando usuários</div></div>}
            </div>
        </section>);
    }

    loadUsers() {
        fetch('https://localhost:6001/api/usuarios?searchName=' + this.state.searchName)
            .then(data => data.json())
            .then(data => {
                this.setState({
                    users: data
                })
            })
            .catch(res => {
                console.log('não foi possivel recuperar os usuários')
            })
    }

    handlerSearchName(ev) {
        this.setState({
            searchName: ev.target.value
        })
    }

    handlerClean(ev) {
        this.setState({ searchName: '' },
            () => this.loadUsers())
    }

    handlerSubmit(ev) {
        this.setState({users:[]})
        this.loadUsers()
        ev.preventDefault()
    }
}