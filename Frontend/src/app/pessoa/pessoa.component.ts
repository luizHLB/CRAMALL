import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { PessoaService } from '../pessoa.service';
import { Pessoa } from '../pessoa';

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.css']
})
export class PessoaComponent implements OnInit {

  dataSaved = false;
  pessoaForm: any;
  allPessoas: Observable<Pessoa[]>;
  pessoaId = null;
  message = null;

  public cepMask = [/\d/, /\d/, /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/];

  constructor(private formBuilder: FormBuilder, private pessoaService: PessoaService) { }

  ngOnInit(): void {
    this.pessoaForm = this.formBuilder.group({
      Nome: ['', [Validators.required]],
      DataNascimento: ['', [Validators.required]],
      Sexo: ['', [Validators.required]],
      Cep: ['',[]],
      Cidade: ['',[]],
      Estado: ['',[]],
      Rua: ['',[]],
      Numero: ['', []],
      Complemento: ['', []]
    });
    this.loadAllPessoas();
  }

  loadAllPessoas(){
    this.allPessoas = this.pessoaService.getAllPessoas();
  }

  onFormSubmit(){
    this.dataSaved = false;
    const pessoa = this.pessoaForm.value;
    this.SavePessoa(pessoa);
    this.pessoaForm.reset();
  }

  SavePessoa(pessoa: Pessoa) {
    console.log(pessoa);
    if(this.pessoaId == null){
      this.pessoaService.postPessoa(pessoa).subscribe (
        () => this.actionComplete(true, 'Record sucessfully created.', true));
        return;
      }

    pessoa.id = this.pessoaId;
    this.pessoaService.putPessoa(this.pessoaId, pessoa).subscribe(
      () => this.actionComplete(true, 'Record sucessfully updated.', true)
    );
  }

  loadPessoa(pessoaId: number){
    console.log(pessoaId);
    this.pessoaService.getPessoaById(pessoaId).subscribe(pessoa => {
      console.log(pessoa);
      this.message = null;
      this.dataSaved = false;
      this.pessoaId = pessoa.id;
      this.pessoaForm.controls['Nome'].setValue(pessoa.nome);
      this.pessoaForm.controls['DataNascimento'].setValue(pessoa.dataNascimento);
      this.pessoaForm.controls['Sexo'].setValue(pessoa.sexo);
      this.pessoaForm.controls['Cep'].setValue(pessoa.cep);
      this.pessoaForm.controls['Cidade'].setValue(pessoa.cidade);
      this.pessoaForm.controls['Estado'].setValue(pessoa.estado);
      this.pessoaForm.controls['Endereco'].setValue(pessoa.rua);
      this.pessoaForm.controls['Numero'].setValue(pessoa.numero);
      this.pessoaForm.controls['Complemento'].setValue(pessoa.complemento);
    });
  }

  deletePessoa(pessoaId: bigint){
    if(confirm("Would you like to remove this record?")) {
      this.pessoaService.deletePessoa(pessoaId).subscribe(
        () => this.actionComplete(true, 'Record sucessfully removed.', true));
    }
  }

  actionComplete(dataSaved: boolean, message: string, loadRecords: boolean) {
    this.resetForm();
    this.dataSaved = dataSaved;
    this.message = message;

    if(loadRecords){
      this.loadAllPessoas();
    }
  }

  resetForm() {
    this.dataSaved = false;
    this.pessoaForm.reset();
    this.message = null;
  }

  consultarCep(cep: string) {
    this.pessoaService.consultarCep(cep).subscribe(endereco => {
        this.pessoaForm.controls['Cidade'].setValue(endereco.localidade);
        this.pessoaForm.controls['Estado'].setValue(endereco.uf);
        this.pessoaForm.controls['Rua'].setValue(endereco.logradouro);
      }
    )
  }
}
