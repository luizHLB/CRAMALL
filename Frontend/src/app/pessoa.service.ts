import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pessoa } from './pessoa';
import { Endereco } from './endereco';

var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};

@Injectable({
  providedIn: 'root'
})
export class PessoaService {

  url = 'http://localhost:50313/api/v1/pessoas'
  constructor(private http: HttpClient) { }

  getAllPessoas(): Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(this.url);
  }

  getPessoaById(pessoaId: number): Observable<Pessoa> {
    const apiUrl = `${this.url}/${pessoaId}`;
    console.log(apiUrl);
    return this.http.get<Pessoa>(apiUrl);
  }

  postPessoa(pessoa: Pessoa): Observable<Pessoa> {
    return this.http.post<Pessoa>(this.url, pessoa, httpOptions);
  }

  putPessoa(pessoaId: bigint, pessoa: Pessoa): Observable<Pessoa> {
    const apiUrl = `${this.url}/${pessoaId}`;
    return this.http.put<Pessoa>(apiUrl, pessoa, httpOptions);
  }

  deletePessoa(pessoaId: bigint) : Observable<number> {
    const apiUrl = `${this.url}/${pessoaId}`;
    return this.http.delete<number>(apiUrl, httpOptions)
  }

  consultarCep(cep: string) : Observable<Endereco>{
    const apiUrl = `${this.url}/consultarCEP?cep=${cep}`
    return this.http.get<Endereco>(apiUrl, httpOptions)
  }
}
