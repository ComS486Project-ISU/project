/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package CananatorX;
import java.util.EventListener;

/**
 *
 * @author prisum
 */
public interface PrisumCanDataListener extends EventListener{
    
    public void CanDataChanged(CanDataArg e);
    
}

